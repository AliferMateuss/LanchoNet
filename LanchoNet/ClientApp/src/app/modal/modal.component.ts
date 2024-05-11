import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';


@Component({
  selector: 'app-modal',
  templateUrl: './modal.component.html',
  styleUrls: ['./modal.component.css']
})
export class ModalComponent {

  constructor(public dialogRef: MatDialogRef<ModalComponent>, @Inject(MAT_DIALOG_DATA) public data: Data) { }

  onNoClick(): void {
    this.dialogRef.close();
  }
}

class Data {
  titulo!: string;
  mensagem!: string;
  botao!: string;
  erro!: boolean;
}
