import { HttpClient } from '@angular/common/http';
import { ChangeDetectorRef, Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-pessoas',
  templateUrl: './pessoas.component.html',
  styleUrls: ['./pessoas.component.css']
})
export class PessoasComponent implements OnInit {
  public pessoa!: Pessoa;
  public formPessoa!: FormGroup;

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string,
    private cdr: ChangeDetectorRef) { }

  ngOnInit(): void {
    this.formPessoa = new FormGroup({
      nome: new FormControl('', [Validators.required]),
      dataNascimento: new FormControl('', [Validators.required]),
      telefone1: new FormControl(''),
      telefone2: new FormControl(''),
      email: new FormControl(''),
      documento: new FormControl('', [Validators.required]),
      ie: new FormControl(''),
      rg: new FormControl(''),
      razaoSocial: new FormControl(''),
      salario: new FormControl(''),
      cargo: new FormControl(''),
      pis: new FormControl(''),
      tipoPessoa: new FormControl(false, [Validators.requiredTrue]),
      cliente: new FormControl(false),
      fornecedor: new FormControl(false),
      funcionario: new FormControl(false),
    });
  }

  salvarPessoa() {

    if (this.formPessoa.valid  && this.checkTipoPessoa()) {
    } else {
      const form = document.querySelector('.needs-validation') as HTMLFormElement;
      form.classList.add('was-validated');

      const valores = this.formPessoa.value;

      this.pessoa = new Pessoa;


    }
  }

  checkTipoPessoa(): boolean {
    const cliente = this.formPessoa.get('cliente')?.value;
    const fornecedor = this.formPessoa.get('fornecedor')?.value;
    const funcionario = this.formPessoa.get('funcionario')?.value;
    this.formPessoa.patchValue({ tipoPessoa: (cliente || fornecedor || funcionario) });
    return cliente || fornecedor || funcionario;
  }

  get nome() { return this.formPessoa.get('nome'); }
  get dataNascimento() { return this.formPessoa.get('dataNascimento'); }
  get telefone1() { return this.formPessoa.get('telefone1'); }
  get telefone2() { return this.formPessoa.get('telefone2'); }
  get email() { return this.formPessoa.get('email'); }
  get documento() { return this.formPessoa.get('documento')!; }
  get ie() { return this.formPessoa.get('ie'); }
  get rg() { return this.formPessoa.get('rg'); }
  get razaoSocial() { return this.formPessoa.get('razaoSocial'); }
  get salario() { return this.formPessoa.get('salario'); }
  get cargo() { return this.formPessoa.get('cargo'); }
  get pis() { return this.formPessoa.get('pis'); }
  get tipoPessoa() { return this.formPessoa.get('tipoPessoa')!; }

}

class Pessoa {
  id!: number;
  nome!: string;
  dataNascimento!: Date;
  telefone1!: string
  telefone2!: string;
  tipoPessoa!: string;
  email!: string;
  cpf!: string;
  cnpj!: string;
  ie!: string;
  rg!: string;
  razaoSocial!: string;
  ativo!: boolean;
  salario!: number;
  cargo!: string;
  pis!: string;
}
