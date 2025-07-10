import { Component } from '@angular/core';
import { Room } from '../../types/room';
import { CommonModule } from '@angular/common';
import { ChatroomService } from '../services/chatroom-service';

@Component({
  selector: 'app-sidebar',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './sidebar.html',
  styleUrl: './sidebar.css',
})
export class Sidebar {
  chatroomService: ChatroomService;

  constructor(private _chatroomService: ChatroomService) {
    this.chatroomService = _chatroomService;
  }

  rooms: Room[] = [
    {
      roomId: '1',
      name: 'General',
      users: [],
      messages: [],
    },
    {
      roomId: '2',
      name: 'Memes',
      users: [],
      messages: [],
    },
    {
      roomId: '3',
      name: 'Coding',
      users: [],
      messages: [],
    },
    {
      roomId: '4',
      name: 'Jobs',
      users: [],
      messages: [],
    },
  ];

  selectRoom(roomId: string) {
    this.chatroomService.switchRoom(roomId);
  }
}
