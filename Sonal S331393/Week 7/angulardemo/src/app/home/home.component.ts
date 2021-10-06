import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
})
export class HomeComponent implements OnInit {

  public listItems: Array<string> = ['Mens Glasses', 'Womens Glasses'];

  constructor() { }

  ngOnInit(): void {
  }

}
