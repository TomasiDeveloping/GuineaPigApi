import {Component, OnInit} from '@angular/core';
import {MatDialogRef} from "@angular/material/dialog";

@Component({
  selector: 'app-paws-info-box',
  templateUrl: './paws-info-box.component.html',
  styleUrls: ['./paws-info-box.component.css']
})
export class PawsInfoBoxComponent implements OnInit {

  constructor(private dialogRef: MatDialogRef<PawsInfoBoxComponent>) {
  }

  ngOnInit(): void {
  }

  onClose() {
    this.dialogRef.close();
  }
}
