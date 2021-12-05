import {Component, Input, OnInit} from '@angular/core';
import {MatDialog} from "@angular/material/dialog";
import {HealthCheckComponent} from "../modals/healt-check/health-check.component";
import {GuineaPigModel} from "../models/guineaPig.model";
import {GuineaPigService} from "../services/guinea-pig.service";
import {GuineaPigEditComponent} from "../modals/guinea-pig-edit/guinea-pig-edit.component";

@Component({
  selector: 'app-guinea-pig-card',
  templateUrl: './guinea-pig-card.component.html',
  styleUrls: ['./guinea-pig-card.component.css']
})
export class GuineaPigCardComponent implements OnInit {
  ago = new Date(2017,2,20);
  check = new Date(2021,11,1);
  // @ts-ignore
  @Input() guineaPig: GuineaPigModel;

  constructor(private dialog: MatDialog, private guineaPigService: GuineaPigService) { }
  ngOnInit(): void {
  }

  onAddHealthCheck() {
    const dialogRef = this.dialog.open(HealthCheckComponent, {
      width: '80%',
      data: this.guineaPig
    });
    dialogRef.afterClosed().subscribe(result =>{
      if (result === 'update') {
        this.updateCard();
      }
    })
  }

  private updateCard() {
    this.guineaPigService.getGuineaPigById(this.guineaPig.id).subscribe((response) => {
      this.guineaPig = response;
    })
  }

  onUpdateGuineaPig() {
    const dialogRef = this.dialog.open(GuineaPigEditComponent, {
      width: '80%',
      data: {isUpdate: true, guineaPig: this.guineaPig}
    })
    dialogRef.afterClosed().subscribe(response => {
      if (response.id) {
        this.guineaPig = response;
      }
    });
  }
}
