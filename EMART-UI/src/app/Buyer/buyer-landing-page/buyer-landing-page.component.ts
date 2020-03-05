import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-buyer-landing-page',
  templateUrl: './buyer-landing-page.component.html',
  styleUrls: ['./buyer-landing-page.component.css']
})
export class BuyerLandingPageComponent implements OnInit {
  collapse:boolean=true;
  constructor() { }

  ngOnInit() {
  }

}
