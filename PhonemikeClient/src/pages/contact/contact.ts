import { Component } from '@angular/core';
import { NavController } from 'ionic-angular';
import {Keyboard } from '@ionic-native/keyboard';
import { Camera,CameraOptions } from '@ionic-native/camera';

@Component({
  selector: 'page-contact',
  templateUrl: 'contact.html'
})
export class ContactPage {

  constructor(public navCtrl: NavController, public keyboard: Keyboard,private camera: Camera) {

  }

  showKeyboard = () => {
    this.keyboard.show();
    // alert('11');

  };
  cameraImgurl: string;
  openCamera = () => {
    const options: CameraOptions = {
      quality: 100,
      destinationType: this.camera.DestinationType.DATA_URL,
      encodingType: this.camera.EncodingType.JPEG,
      mediaType: this.camera.MediaType.PICTURE
    }

    this.camera.getPicture(options).then((imageData) => {
      // imageData is either a base64 encoded string or a file URI
      // If it's base64:
      this.cameraImgurl = 'data:image/jpeg;base64,' + imageData;
    }, (err) => {
      // Handle error
    });
  };
}
