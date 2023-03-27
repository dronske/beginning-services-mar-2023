import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-about',
  templateUrl: './about.component.html',
  styleUrls: ['./about.component.css']
})
export class AboutComponent {

  readonly baseUrl = environment.locationsApi + 'support';
  model$: Observable<SupportModel>;

  constructor(private readonly httpClient:HttpClient) {
    this.model$ = this.httpClient.get<SupportModel>(this.baseUrl)
  }
}

type SupportModel = {
  contactInfo: {
    name: string;
    phone: string;
    email: string;
  },
  uptime: {
    days: number,
    hours: number,
    minutes: number
  }
}