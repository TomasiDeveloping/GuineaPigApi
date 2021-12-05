import {Component, Inject, OnInit} from '@angular/core';
import {MAT_DIALOG_DATA, MatDialog, MatDialogRef} from "@angular/material/dialog";
import {FormControl, FormGroup} from "@angular/forms";
import {GuineaPigModel} from "../../models/guineaPig.model";
import {GuineaPigService} from "../../services/guinea-pig.service";

@Component({
  selector: 'app-guinea-pig-edit',
  templateUrl: './guinea-pig-edit.component.html',
  styleUrls: ['./guinea-pig-edit.component.css']
})
export class GuineaPigEditComponent implements OnInit {
  isUpdate: boolean;
  currentGuineaPig: GuineaPigModel;
  // @ts-ignore
  guineaPigForm: FormGroup;
  genders = ['Weiblich', 'Männlich'];

  constructor(@Inject(MAT_DIALOG_DATA) public data: any,
              private guineaPigService: GuineaPigService,
              private dialogRef: MatDialogRef<GuineaPigEditComponent>) {
    this.isUpdate = data.isUpadte;
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
        }
      });
    } else {
      this.guineaPigService.insertGuineaPig(guineaPig).subscribe((response) => {
        if (response) {
          this.dialogRef.close('update');
        }
      });
    }
  }

  private initForm() {
    this.guineaPigForm = new FormGroup({
      id: new FormControl(this.currentGuineaPig.id),
      name: new FormControl(this.currentGuineaPig.name),
      gender: new FormControl(this.currentGuineaPig.gender),
      race: new FormControl(this.currentGuineaPig.race),
      birth: new FormControl(new Date(this.currentGuineaPig.birth).toISOString().substr(0, 10)),
    });
  }
}
