import {Component, OnInit} from '@angular/core';
import {MatDialogRef} from "@angular/material/dialog";

@Component({
  selector: 'app-eyes-info-box',
  templateUrl: './eyes-info-box.component.html',
  styleUrls: ['./eyes-info-box.component.css']
})
export class EyesInfoBoxComponent implements OnInit {

  constructor(private dialogRef: MatDialogRef<EyesInfoBoxComponent>) {
  }

  ngOnInit(): void {
  }

  onClose() {
    this.dialogRef.close();
  }
}
