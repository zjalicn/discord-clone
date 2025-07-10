import { Component, Input } from '@angular/core';
import { Message } from '../../types/message';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-chat-message',
  imports: [DatePipe],
  templateUrl: './chat-message.html',
  styleUrl: './chat-message.css',
})
export class ChatMessage {
  @Input() message!: Message;
}
