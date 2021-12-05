import {Component, Inject, OnInit} from '@angular/core';
import {FormControl, FormGroup} from "@angular/forms";
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
  healthCheckForm: FormGroup;
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
    this.healthCheckForm = new FormGroup({
      id: new FormControl(0),
      guineaPigId: new FormControl(this.currentGuineaPig.id),
      isPawsCheck: new FormControl(false),
      pawsComment: new FormControl(null),
      isChinCheck: new FormControl(false),
      chinComment: new FormControl(null),
      isMouthCheck: new FormControl(false),
      mouthComment: new FormControl(null),
      isNoseCheck: new FormControl(false),
      noseComment: new FormControl(null),
      isTeethCheck: new FormControl(false),
      teethComment: new FormControl(null),
      isEyesCheck: new FormControl(false),
      eyesComment: new FormControl(null),
      isEarsCheck: new FormControl(false),
      earsComment: new FormControl(null),
      isFurCheck: new FormControl(false),
      furComment: new FormControl(null),
      weight: new FormControl(0.00),
      healthCheckDate: new FormControl(new Date())
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
}
