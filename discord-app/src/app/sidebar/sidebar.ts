import { Component } from '@angular/core';
import { Room } from '../../types/room';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-sidebar',
  imports: [CommonModule],
  templateUrl: './sidebar.html',
  styleUrl: './sidebar.css',
})
export class Sidebar {
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
}
