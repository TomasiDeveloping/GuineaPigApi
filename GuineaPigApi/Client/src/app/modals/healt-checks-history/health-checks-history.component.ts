import {Component, Inject, OnInit} from '@angular/core';
import {HealthCheckModel} from "../../models/healthCheck.model";
import {MAT_DIALOG_DATA, MatDialog} from "@angular/material/dialog";
import {HealthCheckService} from "../../services/health-check.service";
import {GuineaPigModel} from "../../models/guineaPig.model";
import {HealthCheckDetailComponent} from "../healt-check-detail/health-check-detail.component";

@Component({
  selector: 'app-health-checks-history',
  templateUrl: './health-checks-history.component.html',
  styleUrls: ['./health-checks-history.component.css']
})
export class HealthChecksHistoryComponent implements OnInit {

  healthChecks: HealthCheckModel[] = [];
  currentGuineaPig: GuineaPigModel;

  constructor(@Inject(MAT_DIALOG_DATA) public data: any,
              private healthCheckService: HealthCheckService,
              private dialog: MatDialog) {
    this.currentGuineaPig = data;
  }

  ngOnInit(): void {
    this.getHealthChecks();
  }

  getHealthChecks() {
    this.healthCheckService.getHealthChecksByGuineaPigId(this.currentGuineaPig.id).subscribe((response) => {
      this.healthChecks = response;
    });
  }

  onDetails(healthCheck: HealthCheckModel) {
    this.dialog.open(HealthCheckDetailComponent, {
      width: '100%',
      data: healthCheck
    })
  }
}
