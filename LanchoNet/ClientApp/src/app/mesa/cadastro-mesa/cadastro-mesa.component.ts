import { HttpClient, HttpParams } from '@angular/common/http';
import { Component, Inject, RendererFactory2, TemplateRef, ViewChild } from '@angular/core';
import { AbstractControl, FormControl, FormGroup, ValidationErrors, ValidatorFn, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { ActivatedRoute, Router } from '@angular/router';
import { BsModalService } from 'ngx-bootstrap/modal';
import { ModalComponent } from '../../modal/modal.component';

@Component({
  selector: 'app-cadastro-mesa',
  templateUrl: './cadastro-mesa.component.html',
  styleUrls: ['./cadastro-mesa.component.css']
})
export class CadastroMesaComponent {
  mesa: Mesa = new Mesa();
  formMesa?: FormGroup;
  ehAlteracao: boolean = false;

  @ViewChild('modalResposta') modalResposta!: TemplateRef<any>;

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string, private route: ActivatedRoute,
    private dialog: MatDialog, private router: Router) { }

  ngOnInit() {
    var id = this.route.snapshot.paramMap.get('id?');
    if (id) {
      const params = new HttpParams().set("id", id);
      this.http.get<Mesa>(this.baseUrl + 'api/Mesa/RertornaPorId', { params }).subscribe(data => {
        this.mesa = data;
        this.ehAlteracao = true;
      }, error => this.openDialog("Erro ao recuperar mesa", error, "Voltar", true));
    }

    this.formMesa = new FormGroup({
      numero: new FormControl(this.mesa.numero, [Validators.required]),
      status: new FormControl(this.mesa.status),
      capacidade: new FormControl(this.mesa.capacidade, [Validators.required]),
      totalPessoas: new FormControl(this.mesa.totalPessoas)
    });
  }

  openDialog(titulo: string, mensagem: string, botao: string, erro: boolean): void {
    const dialogRef = this.dialog.open(ModalComponent, {
      panelClass: 'top10ClassesFodas',
      hasBackdrop: true,
      data: { titulo: titulo, mensagem: mensagem, botao: botao, erro: erro }
    });
    if (!erro) {
      dialogRef.afterClosed().subscribe(() => {
        this.router.navigate(['/../listaMesas']);
      });
    }
  }

  salvarMesa() {
    if (this.formMesa?.invalid) {
      const form = document.querySelector('.needs-validation') as HTMLFormElement;
      form.classList.add('was-validated');
      return;
    } else {
      const url = this.ehAlteracao ? 'api/Mesa/Atualizar' : 'api/Mesa/Salvar';
      this.http.post<Mesa>(this.baseUrl + url, this.mesa).subscribe(data => {
        this.openDialog(this.ehAlteracao ? "Alteração realizada com sucesso" : "Cadastro realizado com sucesso", "", "Continuar", false);
      }, error => this.openDialog(this.ehAlteracao ? "Erro ao salvar alterações" : "Erro ao cadastrar", error, "Voltar", true));
    }
  }
}

export class Mesa {
  id: number | null = null;
  numero: number | null = null;
  status: string | null = null;
  capacidade: number | null = null;
  totalPessoas: number | null = null;
}
