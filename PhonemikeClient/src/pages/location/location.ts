import { Component } from '@angular/core';
import { NavController, NavParams } from 'ionic-angular';

import { Geolocation } from '@ionic-native/geolocation';

/**
 * Generated class for the LocationPage page.
 *
 * See https://ionicframework.com/docs/components/#navigation for more info on
 * Ionic pages and navigation.
 */

@Component({
  selector: 'page-location',
  templateUrl: 'location.html',
})

export class LocationPage {
  errorinfo: string;
  curLatitude: number;
  curLongitude: number;
  listLocation: any [];
  constructor(public navCtrl: NavController, public navParams: NavParams, private geolocation: Geolocation) {
    
    this.geolocation.getCurrentPosition().then((resp) => {
      this.curLatitude = resp.coords && resp.coords.latitude || -1;
      this.curLongitude = resp.coords && resp.coords.longitude || -1;
    }).catch((error) => {
      this.errorinfo = 'Error getting location' + JSON.stringify(error);
    });

    this.listLocation = [];
    let watch = this.geolocation.watchPosition();
    watch.subscribe((data) => {
      this.listLocation.push({
        latitude: data.coords && data.coords.latitude || -1,
        longitude: data.coords && data.coords.longitude ||-1
      });
    });
  }

}
