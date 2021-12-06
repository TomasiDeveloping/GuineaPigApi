import {Component, OnInit} from '@angular/core';
import {MatDialogRef} from "@angular/material/dialog";

@Component({
  selector: 'app-ears-info-box',
  templateUrl: './ears-info-box.component.html',
  styleUrls: ['./ears-info-box.component.css']
})
export class EarsInfoBoxComponent implements OnInit {

  constructor(private dialogRef: MatDialogRef<EarsInfoBoxComponent>) {
  }

  ngOnInit(): void {
  }

  onClose() {
    this.dialogRef.close();
  }
}
