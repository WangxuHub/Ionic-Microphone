import { Component } from '@angular/core';

import { AboutPage } from '../about/about';
import { ContactPage } from '../contact/contact';
import { HomePage } from '../home/home';
import { LocationPage } from '../location/location';

import { Keyboard } from 'ionic-angular'

@Component({
  templateUrl: 'tabs.html'
})
export class TabsPage {

  tab1Root = HomePage;
  tab2Root = AboutPage;
  tab3Root = ContactPage;
  tab4Root = LocationPage;

  constructor(public keyboard: Keyboard) {
    this.keyboard.onClose(()=>{

    });
    //this.keyboard.willShow();
  }
}
