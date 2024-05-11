import { Directive, HostListener } from '@angular/core';

@Directive({
  selector: '[appImpedeColagem]'
})
export class ImpedeColagemDirective {


  constructor() { }

  @HostListener('paste', ['$event'])
  onPaste(event: ClipboardEvent): void {
    event.preventDefault();
  }

}
