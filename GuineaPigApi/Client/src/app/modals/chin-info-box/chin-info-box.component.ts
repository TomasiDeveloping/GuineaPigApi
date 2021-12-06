import {Component, OnInit} from '@angular/core';
import {MatDialogRef} from "@angular/material/dialog";

@Component({
  selector: 'app-chin-info-box',
  templateUrl: './chin-info-box.component.html',
  styleUrls: ['./chin-info-box.component.css']
})
export class ChinInfoBoxComponent implements OnInit {

  constructor(private dialogRef: MatDialogRef<ChinInfoBoxComponent>) {
  }

  ngOnInit(): void {
  }

  onClose() {
    this.dialogRef.close();
  }
}
