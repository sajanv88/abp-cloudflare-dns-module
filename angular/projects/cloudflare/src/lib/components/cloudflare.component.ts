import { Component, OnInit } from '@angular/core';
import { CloudflareService } from '../services/cloudflare.service';

@Component({
  selector: 'lib-cloudflare',
  template: ` <p>cloudflare works!</p> `,
  styles: [],
})
export class CloudflareComponent implements OnInit {
  constructor(private service: CloudflareService) {}

  ngOnInit(): void {
    this.service.sample().subscribe(console.log);
  }
}
