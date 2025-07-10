import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Message } from '../../types/message';
import { ChatMessage } from '../chat-message/chat-message';

@Component({
  selector: 'app-chatbox',
  imports: [CommonModule, ChatMessage],
  templateUrl: './chatbox.html',
  styleUrl: './chatbox.css',
})
export class Chatbox {
  @Input() messages: Message[] = [];
}
