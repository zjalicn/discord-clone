import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { AsyncPipe } from '@angular/common';
import { Observable } from 'rxjs';
import { Chatbox } from '../chatbox/chatbox';
import { Message } from '../../types/message';
import { IconsModule } from '../shared/icons.module';
import { ChatroomService } from '../services/chatroom-service';

@Component({
  selector: 'app-chat-view',
  standalone: true,
  imports: [Chatbox, IconsModule, FormsModule, AsyncPipe],
  templateUrl: './chat-view.html',
  styleUrl: './chat-view.css',
})
export class ChatView {
  messages$: Observable<Message[]>;
  messageText = '';

  constructor(private chatroomService: ChatroomService) {
    this.messages$ = this.chatroomService.currentRoomMessages$;
  }

  handleSubmitMessage() {
    console.log('sending');
    this.chatroomService.sendMessage(this.messageText);
    this.messageText = '';
  }
}
