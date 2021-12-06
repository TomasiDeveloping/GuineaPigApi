import {Component, Inject, OnInit} from '@angular/core';
import {HealthCheckModel} from "../../models/healthCheck.model";
import {MAT_DIALOG_DATA, MatDialogRef} from "@angular/material/dialog";

@Component({
  selector: 'app-health-check-detail',
  templateUrl: './health-check-detail.component.html',
  styleUrls: ['./health-check-detail.component.css']
})
export class HealthCheckDetailComponent implements OnInit {

  currentHealthCheck: HealthCheckModel;

  constructor(@Inject(MAT_DIALOG_DATA) public data: any,
              private dialogRef: MatDialogRef<HealthCheckDetailComponent>) {
    this.currentHealthCheck = data;
  }

  ngOnInit(): void {
  }

  onClose() {
    this.dialogRef.close();
  }
}
