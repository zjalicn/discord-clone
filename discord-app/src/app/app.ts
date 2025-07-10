import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Sidebar } from './sidebar/sidebar';
import { ChatView } from './chat-view/chat-view';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, Sidebar, ChatView],
  templateUrl: './app.html',
  styleUrl: './app.css',
})
export class App {
  protected readonly title = signal('discord-app');
}
