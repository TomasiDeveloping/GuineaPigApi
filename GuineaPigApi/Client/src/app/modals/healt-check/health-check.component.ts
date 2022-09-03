import {Component, Inject, OnInit} from '@angular/core';
import {UntypedFormControl, UntypedFormGroup} from "@angular/forms";
import {MAT_DIALOG_DATA, MatDialog, MatDialogRef} from "@angular/material/dialog";
import {PawsInfoBoxComponent} from "../paws-info-box/paws-info-box.component";
import {ChinInfoBoxComponent} from "../chin-info-box/chin-info-box.component";
import {EyesInfoBoxComponent} from "../eyes-info-box/eyes-info-box.component";
import {EarsInfoBoxComponent} from "../ears-info-box/ears-info-box.component";
import {FurInfoBoxComponent} from "../fur-info-box/fur-info-box.component";
import {GuineaPigModel} from "../../models/guineaPig.model";
import {HealthCheckService} from "../../services/health-check.service";
import {HealthCheckModel} from "../../models/healthCheck.model";
import {ToastrService} from "ngx-toastr";
import Swal from "sweetalert2";

@Component({
  selector: 'app-health-check',
  templateUrl: './health-check.component.html',
  styleUrls: ['./health-check.component.css']
})
export class HealthCheckComponent implements OnInit {

  // @ts-ignore
  healthCheckForm: UntypedFormGroup;
  isPawsComment = false;
  isChinCheckComment = false;
  isMouthCheckComment = false;
  isNoseCheckComment = false;
  isTeethCheckComment = false;
  isEyesCheckComment = false;
  isEarsCheckComment = false;
  isFurCheckComment = false;

  currentGuineaPig: GuineaPigModel;

  constructor(@Inject(MAT_DIALOG_DATA) public data: any,
              private dialog: MatDialog,
              private healthCheckService: HealthCheckService,
              private toastr: ToastrService,
              private dialogRef: MatDialogRef<HealthCheckComponent>) {
    this.currentGuineaPig = data;
  }

  ngOnInit(): void {
    this.initForm();
  }

  initForm() {
    this.healthCheckForm = new UntypedFormGroup({
      id: new UntypedFormControl(0),
      guineaPigId: new UntypedFormControl(this.currentGuineaPig.id),
      isPawsCheck: new UntypedFormControl(false),
      pawsComment: new UntypedFormControl(null),
      isChinCheck: new UntypedFormControl(false),
      chinComment: new UntypedFormControl(null),
      isMouthCheck: new UntypedFormControl(false),
      mouthComment: new UntypedFormControl(null),
      isNoseCheck: new UntypedFormControl(false),
      noseComment: new UntypedFormControl(null),
      isTeethCheck: new UntypedFormControl(false),
      teethComment: new UntypedFormControl(null),
      isEyesCheck: new UntypedFormControl(false),
      eyesComment: new UntypedFormControl(null),
      isEarsCheck: new UntypedFormControl(false),
      earsComment: new UntypedFormControl(null),
      isFurCheck: new UntypedFormControl(false),
      furComment: new UntypedFormControl(null),
      weight: new UntypedFormControl(0.00),
      healthCheckDate: new UntypedFormControl(new Date())
    });
  }

  onSubmit() {
    const healthCheck: HealthCheckModel = this.healthCheckForm.value as HealthCheckModel;
    this.healthCheckService.insertHealthCheck(healthCheck).subscribe((response) => {
      if (response) {
        this.toastr.success('Gesundheits-Check für ' + this.currentGuineaPig.name + ' hinzugefügt', 'Hinzugefügt');
        this.dialogRef.close('update');
      }
    }, error => {
      Swal.fire('Hinzufügen', 'Fehler beim hinzufügen, ' + error.error, 'error').then(() => {
        this.dialogRef.close();
      })
    })
  }

  onPawsInfo() {
    this.dialog.open(PawsInfoBoxComponent, {
      width: '80%'
    })
  }

  onChinMouthNoseTeethInfo() {
    this.dialog.open(ChinInfoBoxComponent, {
      width: '80%'
    })
  }

  onEyesInfo() {
    this.dialog.open(EyesInfoBoxComponent, {
      width: '80%'
    })
  }

  onEarsInfo() {
    this.dialog.open(EarsInfoBoxComponent, {
      width: '80%'
    })
  }

  onFurInfo() {
    this.dialog.open(FurInfoBoxComponent, {
      width: '80%'
    })
  }

  onClose() {
    this.dialogRef.close();
  }
}
