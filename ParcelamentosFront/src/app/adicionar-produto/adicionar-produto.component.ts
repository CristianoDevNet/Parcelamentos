import { Component, OnInit } from '@angular/core';

import { FormGroup, FormBuilder, Validators } from "@angular/forms";

@Component({
  selector: 'app-adicionar-produto',
  templateUrl: './adicionar-produto.component.html',
  styles: []
})
export class AdicionarProdutoComponent implements OnInit {

  angForm: FormGroup;

  constructor(private fb: FormBuilder) 
  { 
    this.createForm();
  }

  createForm()
  {
    this.angForm = this.fb.group({
      NomeProduto: ['', Validators.required]
    })
  }

  ngOnInit() {
  }

}
