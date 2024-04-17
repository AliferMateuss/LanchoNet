import { HttpClient } from '@angular/common/http';
import { ChangeDetectorRef, Component, Inject, OnInit, ViewChild } from '@angular/core';
import { AbstractControl, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { GenericValidator } from '../Validators/validator.component';
import { animate, style, transition, trigger } from '@angular/animations';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort, Sort } from '@angular/material/sort';
import { BsModalService } from 'ngx-bootstrap/modal';
import * as $ from 'jquery'

@Component({
  selector: 'app-pessoas',
  templateUrl: './pessoas.component.html',
  styleUrls: ['./pessoas.component.css'],
  animations: [
    trigger('slideLeftToRight', [
      transition(':enter', [
        style({ transform: 'translateX(-100%)' }),
        animate('300ms ease-out', style({ transform: 'translateX(0)' })),
      ]),
      transition(':leave', [
        animate('300ms ease-out', style({ transform: 'translateX(-100%)' })),
      ])
    ]),
    trigger('slideLeftToRightAndBottomToTop', [
      transition(':enter', [
        style({ transform: 'translateX(-100%) translateY(100%)' }),
        animate('300ms ease-out', style({ transform: 'translateX(0) translateY(0)' })),
      ]),
      transition(':leave', [
        animate('300ms ease-out', style({ transform: 'translateX(-100%) translateY(100%)' })),
      ])
    ])
  ]
})
export class PessoasComponent implements OnInit {
  public pessoa!: Pessoa;
  public formPessoa!: FormGroup;
  public formEndereco!: FormGroup;
  public Endereco: Endereco | null = null;
  documentoOK: boolean = true;
  documento: string = '';
  documentoPassou: boolean = false;
  cliente: boolean = false;
  funcionario: boolean = false;
  fornecedor: boolean = false;
  tipoPessoa: boolean = false;
  dataSource!: MatTableDataSource<Endereco>;
  pageIndex!: number;
  pageSize!: number;
  displayedColumns: string[] = ['nome', 'bairro', 'cidade', 'Acoes'];

  @ViewChild('paginator') paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string,
    private cdr: ChangeDetectorRef, private validator: GenericValidator, private modalService: BsModalService) { }

  ngOnInit(): void {
  }

  validarDocumento() {

    this.documentoPassou = false;
    this.cliente = false;
    this.fornecedor = false;
    this.funcionario = false;
    const documentoLimpo = this.documento.replace(/[^\d]+/g, '');

    let validatorFn;
    if (documentoLimpo.length === 11) {
      validatorFn = GenericValidator.isValidCpf();
    } else if (documentoLimpo.length === 14) {
      validatorFn = GenericValidator.isValidCnpj();
    } else {
      return;
    }

    if (validatorFn) {
      const error = validatorFn({ value: this.documento } as AbstractControl);
      this.documentoOK = !error;
      if (error) {
      } else {
        this.documentoPassou = true;
        if (this.pessoa != null || this.pessoa != undefined)
          this.limpaPessoa();
        this.pessoa = new Pessoa();
        this.pessoa.cpf = documentoLimpo.length === 11 ? documentoLimpo : "";
        this.pessoa.cnpj = documentoLimpo.length === 14 ? documentoLimpo : "";

        if (this.formPessoa === undefined || this.formPessoa === null)
          this.formPessoa = new FormGroup({
            nome: new FormControl(this.pessoa.nome),
            dataNascimento: new FormControl(this.pessoa.dataNascimento),
            telefone1: new FormControl(this.pessoa.telefone1),
            telefone2: new FormControl(this.pessoa.telefone2),
            email: new FormControl(this.pessoa.email),
            ie: new FormControl(this.pessoa.ie),
            cpf: new FormControl({
              value: this.pessoa.cpf,
              disabled: this.documento.length === 11
            }),
            cnpj: new FormControl({
              value: this.pessoa.cnpj,
              disabled: this.documento.length === 14
            }),
            rg: new FormControl(this.pessoa.rg),
            razaoSocial: new FormControl(this.pessoa.razaoSocial),
            salario: new FormControl(this.pessoa.salario),
            cargo: new FormControl(this.pessoa.cargo),
            pis: new FormControl(this.pessoa.pis),
            cliente: new FormControl(false),
            fornecedor: new FormControl(false),
            funcionario: new FormControl(false),
          });
      }
    }
  }

  selecionarTipoDocumento(tipo: string) {

    const form = document.querySelector('.needs-validation') as HTMLFormElement;
    form.classList.remove('was-validated');

    if (this.fornecedor || this.cliente || this.funcionario) {
      this.tipoPessoa = true;

      const formControls = this.formPessoa.controls;
      Object.keys(formControls).forEach(controlName => {
        formControls[controlName].clearValidators();
        formControls[controlName].updateValueAndValidity();
      });

      if (this.cliente && (this.fornecedor || this.documento.length === 14)) {
        formControls.razaoSocial.setValidators(Validators.required);
        formControls.razaoSocial.updateValueAndValidity();
        formControls.telefone1.setValue(this.pessoa.razaoSocial);
        formControls.telefone1.setValidators(Validators.required);
        formControls.telefone1.updateValueAndValidity();
        formControls.telefone1.setValue(this.pessoa.telefone1);
        formControls.cnpj.setValidators(Validators.required);
        formControls.cnpj.updateValueAndValidity();
        formControls.cnpj.setValue(this.pessoa.cnpj);
        formControls.cnpj.disable();
      } else if (this.cliente && this.funcionario) {
        formControls.nome.setValidators(Validators.required);
        formControls.nome.updateValueAndValidity();
        formControls.nome.setValue(this.pessoa.nome);
        formControls.cpf.setValidators(Validators.required);
        formControls.cpf.updateValueAndValidity();
        formControls.cpf.setValue(this.pessoa.cpf);
        formControls.cpf.disable();
        formControls.dataNascimento.setValidators(Validators.required);
        formControls.dataNascimento.updateValueAndValidity();
        formControls.dataNascimento.setValue(this.pessoa.dataNascimento);
        formControls.pis.setValidators(Validators.required);
        formControls.pis.updateValueAndValidity();
        formControls.pis.setValue(this.pessoa.pis);
        formControls.salario.setValidators(Validators.required);
        formControls.salario.updateValueAndValidity();
        formControls.salario.setValue(this.pessoa.salario);
        formControls.cargo.setValidators(Validators.required);
        formControls.cargo.updateValueAndValidity();
        formControls.cargo.setValue(this.pessoa.cargo);
      } else if (this.cliente && this.documento.length === 11) {
        formControls.nome.setValidators(Validators.required);
        formControls.nome.updateValueAndValidity();
        formControls.nome.setValue(this.pessoa.nome);
        formControls.cpf.setValidators(Validators.required);
        formControls.cpf.updateValueAndValidity();
        formControls.cpf.setValue(this.pessoa.cpf);
        formControls.cpf.disable();
        formControls.dataNascimento.setValidators(Validators.required);
        formControls.dataNascimento.updateValueAndValidity();
        formControls.dataNascimento.setValue(this.pessoa.dataNascimento);
      } else if (this.fornecedor) {
        formControls.razaoSocial.setValidators(Validators.required);
        formControls.razaoSocial.updateValueAndValidity();
        formControls.razaoSocial.setValue(this.pessoa.razaoSocial);
        formControls.telefone1.setValidators(Validators.required);
        formControls.telefone1.updateValueAndValidity();
        formControls.telefone1.setValue(this.pessoa.telefone1);
        formControls.cnpj.setValidators(Validators.required);
        formControls.cnpj.updateValueAndValidity();
        formControls.cnpj.setValue(this.pessoa.cnpj);
        formControls.cnpj.disable()
      } else if (this.funcionario) {
        formControls.nome.setValidators(Validators.required);
        formControls.nome.updateValueAndValidity();
        formControls.nome.setValue(this.pessoa.nome);
        formControls.cpf.setValidators(Validators.required);
        formControls.cpf.updateValueAndValidity();
        formControls.cpf.setValue(this.pessoa.cpf);
        formControls.cpf.disable();
        formControls.dataNascimento.setValidators(Validators.required);
        formControls.dataNascimento.updateValueAndValidity();
        formControls.dataNascimento.setValue(this.pessoa.dataNascimento);
        formControls.pis.setValidators(Validators.required);
        formControls.pis.updateValueAndValidity();
        formControls.pis.setValue(this.pessoa.pis);
        formControls.salario.setValidators(Validators.required);
        formControls.salario.updateValueAndValidity();
        formControls.salario.setValue(this.pessoa.salario);
        formControls.cargo.setValidators(Validators.required);
        formControls.cargo.updateValueAndValidity();
        formControls.cargo.setValue(this.pessoa.cargo);
      }
    }
    else {
      this.tipoPessoa = false;
    }
  }

  montaTipoPessoa() {

  }

  salvarPessoa() {
    Object.keys(this.formPessoa.controls).forEach((campo) => {
      this.formPessoa.get(campo)?.markAsTouched();
      this.formPessoa.get(campo)?.markAsDirty();
    });
    console.log(this.formPessoa)
    if (this.formPessoa.valid) {
      console.log(this.pessoa);
      this.RevalidaPessoa();
    } else {
      const form = document.querySelector('.needs-validation') as HTMLFormElement;
      form.classList.add('was-validated');

      const valores = this.formPessoa.value;


    }
  }

  adicionarEndereco() {
    this.Endereco = new Endereco();
    this.formEndereco = new FormGroup({
      idCidade: new FormControl(this.Endereco.idCidade, [Validators.required]),
      cep: new FormControl(this.Endereco.cep, [Validators.required]),
      rua: new FormControl(this.Endereco.rua, [Validators.required]),
      numero: new FormControl(this.Endereco.numero, [Validators.required]),
      complemento: new FormControl(this.Endereco.complemento),
      bairro: new FormControl(this.Endereco.bairro, [Validators.required]),
    });
  }

  alterarEndereco(endereco: Endereco) {
    this.Endereco = endereco;
    this.formEndereco = new FormGroup({
      idCidade: new FormControl(this.Endereco.idCidade, [Validators.required]),
      cep: new FormControl(this.Endereco.cep, [Validators.required]),
      rua: new FormControl(this.Endereco.rua, [Validators.required]),
      numero: new FormControl(this.Endereco.numero, [Validators.required]),
      complemento: new FormControl(this.Endereco.complemento),
      bairro: new FormControl(this.Endereco.bairro, [Validators.required]),
    });
  }

  removerEndereco(endereco: Endereco) {
    const index = this.pessoa.enderecos.indexOf(endereco);
    if (index !== -1) {
      this.pessoa.enderecos.splice(index, 1);
    }
    this.dataSource = new MatTableDataSource<Endereco>(this.pessoa.enderecos);
    this.cdr.detectChanges();
  }

  salvarEndereco(novo: boolean) {

    Object.keys(this.formEndereco.controls).forEach((campo) => {
      this.formPessoa.get(campo)?.markAsTouched();
      this.formPessoa.get(campo)?.markAsDirty();
    });

    if (this.formEndereco.valid) {

      if (this.Endereco != null) {
        const index = this.pessoa.enderecos.indexOf(this.Endereco);
        if (index !== -1) {
          this.pessoa.enderecos.splice(index, 1);
        }
        this.pessoa.enderecos.push(this.Endereco);
      }

      console.log(this.pessoa.enderecos)
      console.log(this.Endereco)
      console.log(this.formEndereco)
      if (novo) {
        this.Endereco = new Endereco();
      } else {
        //$("#modalEndereco").toggle();
        //$('.modal-backdrop').toggle();]
        this.modalService.hide('modalEndereco');
        this.dataSource = new MatTableDataSource<Endereco>(this.pessoa.enderecos);
        this.cdr.detectChanges();
      }
    } else {
      console.log("Npassou")
      console.log(this.Endereco)
      console.log(this.formEndereco)
      Object.keys(this.formEndereco.controls).forEach((campo) => {
        console.log(campo ,this.formPessoa.get(campo)?.valid)
      });
      const form = document.querySelector('.needs-validation.endereco') as HTMLFormElement;
      form.classList.add('was-validated');
    }
  }

  fecharModal() {
    this.Endereco = null;
  }

  RevalidaPessoa() {
    this.pessoa.nome = ((this.cliente || this.funcionario) && this.documento.length === 11) || (this.cliente && this.documento.length === 14) ? this.pessoa.nome : "";
    this.pessoa.cpf = ((this.cliente || this.funcionario) && this.documento.length === 11) || (this.cliente && this.documento.length === 14) ? this.pessoa.cpf : "";
    this.pessoa.rg = ((this.cliente || this.funcionario) && this.documento.length === 11) || (this.cliente && this.documento.length === 14) ? this.pessoa.rg : "";
    this.pessoa.ie = this.documento.length === 14 ? this.pessoa.ie : "";
    this.pessoa.razaoSocial = this.documento.length === 14 ? this.pessoa.razaoSocial : "";
    this.pessoa.dataNascimento = (this.cliente || this.funcionario) && this.documento.length === 11 ? this.pessoa.dataNascimento : null;
    this.pessoa.cargo = this.funcionario ? this.pessoa.cargo : "";
    this.pessoa.pis = this.funcionario ? this.pessoa.pis : "";
    this.pessoa.salario = this.funcionario ? this.pessoa.salario : null;
  }

  limpaPessoa() {
    this.pessoa.id = null;
    this.pessoa.nome = null;
    this.pessoa.dataNascimento = null;
    this.pessoa.telefone1 = null;
    this.pessoa.telefone2 = null;
    this.pessoa.tipoPessoa = null;
    this.pessoa.email = null;
    this.pessoa.cpf = null;
    this.pessoa.cnpj = null;
    this.pessoa.ie = null;
    this.pessoa.rg = null;
    this.pessoa.razaoSocial = null;
    this.pessoa.ativo = null;
    this.pessoa.salario = null;
    this.pessoa.cargo = null;
    this.pessoa.pis = null;
    this.pessoa.enderecos = [];
  }

  get nome() { return this.formPessoa.get('nome')!; }
  get dataNascimento() { return this.formPessoa.get('dataNascimento')!; }
  get telefone1() { return this.formPessoa.get('telefone1')!; }
  get telefone2() { return this.formPessoa.get('telefone2')!; }
  get email() { return this.formPessoa.get('email')!; }
  get ie() { return this.formPessoa.get('ie')!; }
  get rg() { return this.formPessoa.get('rg')!; }
  get razaoSocial() { return this.formPessoa.get('razaoSocial')!; }
  get salario() { return this.formPessoa.get('salario')!; }
  get cargo() { return this.formPessoa.get('cargo')!; }
  get pis() { return this.formPessoa.get('pis')!; }
  get idPessoa() {
    return this.formEndereco.get('idPessoa')!;
  }

  get idCidade() {
    return this.formEndereco.get('idCidade')!;
  }

  get cep() {
    return this.formEndereco.get('cep')!;
  }

  get rua() {
    return this.formEndereco.get('rua')!;
  }

  get numero() {
    return this.formEndereco.get('numero')!;
  }

  get complemento() {
    return this.formEndereco.get('complemento')!;
  }

  get bairro() {
    return this.formEndereco.get('bairro')!;
  }

}

class Pessoa {
  public id: number | null = null;
  public nome: string | null = null;
  public dataNascimento: Date | null = null;
  public telefone1: string | null = null
  public telefone2: string | null = null;
  public tipoPessoa: string | null = null;
  public email: string | null = null;
  public cpf: string | null = null;
  public cnpj: string | null = null;
  public ie: string | null = null;
  public rg: string | null = null;
  public razaoSocial: string | null = null;
  public ativo: boolean | null = null;
  public salario: number | null = null;
  public cargo: string | null = null;
  public pis: string | null = null;
  public enderecos: Endereco[] = [];
}

class Endereco {
  public idPessoa: number | null = null;
  public idCidade: string | null = null;
  public cep: string | null = null;
  public rua: string | null = null;
  public numero: string | null = null;
  public complemento: string | null = null;
  public bairro: string | null = null;
}
