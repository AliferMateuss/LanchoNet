import { HttpClient, HttpParams } from '@angular/common/http';
import { Component, Inject, RendererFactory2, TemplateRef, ViewChild } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { ActivatedRoute, Router } from '@angular/router';
import { BsModalService } from 'ngx-bootstrap/modal';
import { ModalComponent } from '../../modal/modal.component';

@Component({
  selector: 'app-cadastro-tipos-pagamentos',
  templateUrl: './cadastro-tipos-pagamentos.component.html',
  styleUrls: ['./cadastro-tipos-pagamentos.component.css']
})
export class CadastroTiposPagamentosComponent {
  tipoPagamento: TipoPagamento = new TipoPagamento();
  formTipoPagamento?: FormGroup;
  ehAlteracao: boolean = false;

  @ViewChild('modalResposta') modalResposta!: TemplateRef<any>;

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string, private route: ActivatedRoute,
    private dialog: MatDialog, private router: Router) { }

  ngOnInit() {
    var id = this.route.snapshot.paramMap.get('id?');
    if (id) {
      const params = new HttpParams().set("id", id);
      this.http.get<TipoPagamento>(this.baseUrl + 'api/TipoPagamento/RertornaPorId', { params }).subscribe(data => {
        this.tipoPagamento = data;
        this.ehAlteracao = true;
      }, error => this.openDialog("Erro ao recuperar tipo de pagamento", error, "Voltar", true));
    }

    this.formTipoPagamento = new FormGroup({
      nome: new FormControl(this.tipoPagamento.nome, [Validators.required]),
      juros: new FormControl(this.tipoPagamento.juros)
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
        this.router.navigate(['/../listaTipoPagamentos']);
      });
    }
  }

  salvarTipoPagamento() {
    if (this.formTipoPagamento?.invalid) {
      const form = document.querySelector('.needs-validation') as HTMLFormElement;
      form.classList.add('was-validated');
      return;
    } else {
      const url = this.ehAlteracao ? 'api/TipoPagamento/Atualizar' : 'api/TipoPagamento/Salvar';
      this.http.post<any>(this.baseUrl + url, this.tipoPagamento).subscribe(data => {
        this.openDialog(this.ehAlteracao ? "Alteração realizada com sucesso" : "Cadastro realizado com sucesso", "", "Continuar", false);
      }, error => this.openDialog(this.ehAlteracao ? "Erro ao salvar alterações" : "Erro ao cadastrar", error, "Voltar", true));
    }
  }
}

export class TipoPagamento {
  id: number | null = null;
  nome: string | null = null;
  juros: number | null = null;
}
