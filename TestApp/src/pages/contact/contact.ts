import { Component } from '@angular/core';
import { NavController } from 'ionic-angular';
import {Keyboard } from '@ionic-native/keyboard';


@Component({
  selector: 'page-contact',
  templateUrl: 'contact.html'
})
export class ContactPage {

  constructor(public navCtrl: NavController, public keyboard: Keyboard) {

  }

  showKeyboard=()=>{
    this.keyboard.show();
   // alert('11');

  };
}
