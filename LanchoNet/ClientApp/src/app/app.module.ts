import { BrowserModule } from '@angular/platform-browser';
import { DEFAULT_CURRENCY_CODE, LOCALE_ID, NgModule, RendererFactory2, importProvidersFrom } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { MatNativeDateModule, MatOptionModule } from '@angular/material/core';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { PessoasComponent } from './pessoas/Cadastro/pessoas.component';
import { provideEnvironmentNgxMask, NgxMaskDirective, NgxMaskPipe } from 'ngx-mask';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatTableModule } from '@angular/material/table';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatSortModule } from '@angular/material/sort';
import { ModalModule } from 'ngx-bootstrap/modal';
import { NgSelectModule } from '@ng-select/ng-select';
import { CommonModule } from '@angular/common';
import { CurrencyMaskModule } from 'ng2-currency-mask';
import { ListaPessoasComponent } from './pessoas/Consulta/lista-pessoas.component';
import { CadastroProdutosComponent } from './produtos/cadastro-produtos/cadastro-produtos.component';
import { ListaProdutosComponent } from './produtos/lista-produtos/lista-produtos.component';
import { MatDialogModule } from '@angular/material/dialog';
import { ModalComponent } from './modal/modal.component';
import { ImpedeColagemDirective } from './impede-colagem.directive';
import { CadastroUsuariosComponent } from './usuarios/cadastro-usuarios/cadastro-usuarios.component';
import { ListaUsuariosComponent } from './usuarios/lista-usuarios/lista-usuarios.component';
import { CadastroGrupoUsuariosComponent } from './grupo-usuarios/cadastro-grupo-usuarios/cadastro-grupo-usuarios.component';
import { ListaGrupoUsuariosComponent } from './grupo-usuarios/lista-grupo-usuarios/lista-grupo-usuarios.component';
import { CadastroMesaComponent } from './mesa/cadastro-mesa/cadastro-mesa.component';
import { ListaMesasComponent } from './mesa/lista-mesas/lista-mesas.component';
import { ListaTiposPagamentosComponent } from './tipo-pagamento/lista-tipos-pagamentos/lista-tipos-pagamentos.component';
import { CadastroTiposPagamentosComponent } from './tipo-pagamento/cadastro-tipos-pagamentos/cadastro-tipos-pagamentos.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    PessoasComponent,
    ListaPessoasComponent,
    CadastroProdutosComponent,
    ListaProdutosComponent,
    ModalComponent,
    ImpedeColagemDirective,
    CadastroUsuariosComponent,
    ListaUsuariosComponent,
    CadastroGrupoUsuariosComponent,
    ListaGrupoUsuariosComponent,
    CadastroMesaComponent,
    ListaMesasComponent,
    ListaTiposPagamentosComponent,
    CadastroTiposPagamentosComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    BrowserAnimationsModule,
    FormsModule,
    CommonModule,
    ReactiveFormsModule,
    NgxMaskDirective,
    NgxMaskPipe,
    MatTableModule,
    MatPaginatorModule,
    MatSortModule,
    NgSelectModule,
    CurrencyMaskModule,
    MatOptionModule,
    MatNativeDateModule,
    MatDialogModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'cadastroPessoas/:id?', component: PessoasComponent },
      { path: 'listaPessoas', component: ListaPessoasComponent },
      { path: 'listaProdutos', component: ListaProdutosComponent },
      { path: 'cadastroProdutos/:id?', component: CadastroProdutosComponent },
      { path: 'listaMesas', component: ListaMesasComponent },
      { path: 'cadastroMesas/:id?', component: CadastroMesaComponent },
      { path: 'listaTiposPagamento', component: ListaTiposPagamentosComponent },
      { path: 'cadastroTiposPagamento/:id?', component: CadastroTiposPagamentosComponent },
      { path: 'listaGruposUsuarios', component: ListaGrupoUsuariosComponent },
      { path: 'cadastroGruposUsuarios/:id?', component: CadastroGrupoUsuariosComponent },
      { path: 'listaUsuarios', component: ListaUsuariosComponent },
      { path: 'cadastroUsuarios/:id?', component: CadastroUsuariosComponent },
    ])
  ],
  providers: [provideEnvironmentNgxMask(),
  { provide: LOCALE_ID, useValue: 'pt- BR' },
    { provide: DEFAULT_CURRENCY_CODE, useValue: 'BRL' },
    importProvidersFrom(MatNativeDateModule)],
  bootstrap: [AppComponent],
})
export class AppModule { }
