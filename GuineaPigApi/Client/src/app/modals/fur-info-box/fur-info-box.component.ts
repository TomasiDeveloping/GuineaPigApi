import {Component, OnInit} from '@angular/core';
import {MatDialogRef} from "@angular/material/dialog";

@Component({
  selector: 'app-fur-info-box',
  templateUrl: './fur-info-box.component.html',
  styleUrls: ['./fur-info-box.component.css']
})
export class FurInfoBoxComponent implements OnInit {

  constructor(private dialogRef: MatDialogRef<FurInfoBoxComponent>) {
  }

  ngOnInit(): void {
  }

  onClose() {
    this.dialogRef.close();
  }
}
