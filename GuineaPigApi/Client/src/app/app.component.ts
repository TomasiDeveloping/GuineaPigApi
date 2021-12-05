import {Component, OnInit} from '@angular/core';
import {GuineaPigService} from "./services/guinea-pig.service";
import {GuineaPigModel} from "./models/guineaPig.model";
import {MatDialog} from "@angular/material/dialog";
import {GuineaPigEditComponent} from "./modals/guinea-pig-edit/guinea-pig-edit.component";
import Swal from "sweetalert2";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'Gesundheits-Check';
  guineaPigs: GuineaPigModel[] = [];

  constructor(private guineaPigService: GuineaPigService,
              private dialog: MatDialog) {
  }

  ngOnInit(): void {
    this.getGuineaPigs();
  }

  onAddGuineaPig() {
    const guineaPig: GuineaPigModel = new class implements GuineaPigModel {
      birth = new Date();
      gender = '';
      id = 0;
      lastHealthCheck = new Date();
      name = '';
      race = '';
    }
    const dialogRef = this.dialog.open(GuineaPigEditComponent, {
      width: '80%',
      data: {isUpdate: false, guineaPig: guineaPig}
    })
    dialogRef.afterClosed().subscribe(response => {
      if (response === 'update') {
        this.getGuineaPigs();
      }
    })
  }

  private getGuineaPigs() {
    this.guineaPigService.getGuineaPigs().subscribe((response) => {
      this.guineaPigs = response;
    }, error => {
      Swal.fire('Laden', 'Fehler beim Laden aus der Datenbank, ' + error.error, 'error').then();
    })
  }
}
