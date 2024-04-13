import { Component } from '@angular/core';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {
  menuAberto: boolean = false;
  subMenuAberto: SubMenuAberto = {
    cadastros: false,
    movimentos: false
  };

  alternarMenu() {
    this.menuAberto = !this.menuAberto;
  }

  fecharMenu() {
    this.menuAberto = false;
  }


  toggleSubMenu(subMenu: SubMenuKey) {
    this.subMenuAberto[subMenu] = !this.subMenuAberto[subMenu];

    //const collapseElement = document.getElementById(subMenu) as HTMLElement;

    //if (this.subMenuAberto[subMenu]) {
    //  collapseElement.classList.add('show');
    //} else {
    //  collapseElement.classList.remove('show');
    //}
  }
}
interface SubMenuAberto {
  movimentos: boolean;
  cadastros: boolean;
}

type SubMenuKey = keyof SubMenuAberto;
