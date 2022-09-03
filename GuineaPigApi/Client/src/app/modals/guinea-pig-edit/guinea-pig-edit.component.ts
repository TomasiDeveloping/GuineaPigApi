import {Component, Inject, OnInit} from '@angular/core';
import {MAT_DIALOG_DATA, MatDialogRef} from "@angular/material/dialog";
import {UntypedFormControl, UntypedFormGroup} from "@angular/forms";
import {GuineaPigModel} from "../../models/guineaPig.model";
import {GuineaPigService} from "../../services/guinea-pig.service";
import {ToastrService} from "ngx-toastr";
import Swal from 'sweetalert2';

@Component({
  selector: 'app-guinea-pig-edit',
  templateUrl: './guinea-pig-edit.component.html',
  styleUrls: ['./guinea-pig-edit.component.css']
})
export class GuineaPigEditComponent implements OnInit {
  isUpdate: boolean;
  currentGuineaPig: GuineaPigModel;
  // @ts-ignore
  guineaPigForm: UntypedFormGroup;
  genders = ['Weiblich', 'Männlich'];

  constructor(@Inject(MAT_DIALOG_DATA) public data: any,
              private guineaPigService: GuineaPigService,
              private toastr: ToastrService,
              private dialogRef: MatDialogRef<GuineaPigEditComponent>) {
    this.isUpdate = data.isUpdate;
    this.currentGuineaPig = data.guineaPig;
  }

  ngOnInit(): void {
    this.initForm();
  }

  onSubmit() {
    const guineaPig: GuineaPigModel = this.guineaPigForm.value as GuineaPigModel;
    if (guineaPig.id > 0) {
      this.guineaPigService.updateGuineaPig(guineaPig.id, guineaPig).subscribe((response) => {
        if (response) {
          this.dialogRef.close(response);
          this.toastr.success(response.name + ' erfolgreich aktualisiert', 'Update');
        }
      }, error => {
        Swal.fire('Update', 'Fehler beim Update, ' + error.error, 'error').then(() => {
          this.dialogRef.close();
        })
      });
    } else {
      this.guineaPigService.insertGuineaPig(guineaPig).subscribe((response) => {
        if (response) {
          this.dialogRef.close('update');
          this.toastr.success(response.name + ' erfolgreich hinzugefügt', 'Hinzugefügt');
        }
      }, error => {
        Swal.fire('Hinzufügen', 'Fehler beim hinzufügen, ' + error.error, 'error').then(() => {
          this.dialogRef.close();
        })
      });
    }
  }

  private initForm() {
    let lastHealthCheck = null;
    if (this.currentGuineaPig.lastHealthCheck) {
      lastHealthCheck = this.currentGuineaPig.lastHealthCheck;
    }

    this.guineaPigForm = new UntypedFormGroup({
      id: new UntypedFormControl(this.currentGuineaPig.id),
      name: new UntypedFormControl(this.currentGuineaPig.name),
      gender: new UntypedFormControl(this.currentGuineaPig.gender),
      race: new UntypedFormControl(this.currentGuineaPig.race),
      birth: new UntypedFormControl(new Date(this.currentGuineaPig.birth).toISOString().substr(0, 10)),
      lastHealthCheck: new UntypedFormControl(lastHealthCheck)
    });
  }

  onClose() {
    this.dialogRef.close();
  }
}
