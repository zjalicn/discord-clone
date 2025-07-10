import { Component } from '@angular/core';
import { Chatbox } from '../chatbox/chatbox';

@Component({
  selector: 'app-chat-view',
  imports: [Chatbox],
  templateUrl: './chat-view.html',
  styleUrl: './chat-view.css',
})
export class ChatView {}
