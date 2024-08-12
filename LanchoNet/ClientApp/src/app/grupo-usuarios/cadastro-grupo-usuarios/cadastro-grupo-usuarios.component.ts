import { HttpClient, HttpParams } from '@angular/common/http';
import { Component, Inject, RendererFactory2, TemplateRef, ViewChild } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { ActivatedRoute, Router } from '@angular/router';
import { BsModalService } from 'ngx-bootstrap/modal';
import { ModalComponent } from '../../modal/modal.component';

@Component({
  selector: 'app-cadastro-grupo-usuarios',
  templateUrl: './cadastro-grupo-usuarios.component.html',
  styleUrls: ['./cadastro-grupo-usuarios.component.css']
})
export class CadastroGrupoUsuariosComponent {
  grupoUsuario: GrupoUsuario = new GrupoUsuario();
  formGrupoUsuario?: FormGroup;
  ehAlteracao: boolean = false;

  @ViewChild('modalResposta') modalResposta!: TemplateRef<any>;

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string, private route: ActivatedRoute,
    private dialog: MatDialog, private router: Router) { }

  ngOnInit() {
    var id = this.route.snapshot.paramMap.get('id?');
    if (id) {
      const params = new HttpParams().set("id", id);
      this.http.get<GrupoUsuario>(this.baseUrl + 'api/GrupoUsuario/RertornaPorId', { params }).subscribe(data => {
        this.grupoUsuario = data;
        this.ehAlteracao = true;
      }, error => this.openDialog("Erro ao recuperar grupo de usuário", error, "Voltar", true));
    }

    this.formGrupoUsuario = new FormGroup({
      nome: new FormControl(this.grupoUsuario.nome, [Validators.required])
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
        this.router.navigate(['/../listaGrupoUsuarios']);
      });
    }
  }

  salvarGrupoUsuario() {
    if (this.formGrupoUsuario?.invalid) {
      const form = document.querySelector('.needs-validation') as HTMLFormElement;
      form.classList.add('was-validated');
      return;
    } else {
      const url = this.ehAlteracao ? 'api/GrupoUsuario/Atualizar' : 'api/GrupoUsuario/Salvar';
      this.http.post<any>(this.baseUrl + url, this.grupoUsuario).subscribe(data => {
        this.openDialog(this.ehAlteracao ? "Alteração realizada com sucesso" : "Cadastro realizado com sucesso", "", "Continuar", false);
      }, error => this.openDialog(this.ehAlteracao ? "Erro ao salvar alterações" : "Erro ao cadastrar", error, "Voltar", true));
    }
  }
}
export class GrupoUsuario {
  id: number | null = null;
  nome: string | null = null;
}
