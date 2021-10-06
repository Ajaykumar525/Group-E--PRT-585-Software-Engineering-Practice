import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {
  public listItems: Array<string> = ['Women Theodre Glass',
  'Women Day Glass',
  'Women Adler Glass',
  'Men Dustin Glass',
  'Men Thordore Half Windsor Glass',
  'Men Wyatt Glass'
];
  constructor() { }

  ngOnInit(): void {
  }

}
