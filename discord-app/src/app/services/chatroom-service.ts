import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { Room } from '../../types/room';
import { User } from '../../types/user';
import { Message } from '../../types/message';

@Injectable({
  providedIn: 'root',
})
export class ChatroomService {
  private _currentChatRoomId = new BehaviorSubject<string | null>(null);
  private _currentRoomId = new BehaviorSubject<string | null>(null);
  private _rooms = new BehaviorSubject<Room[]>([]);
  private _users = new BehaviorSubject<User[]>([]);

  private _currentRoomMessages = new BehaviorSubject<Message[]>([]);

  currentChatRoomId$ = this._currentChatRoomId.asObservable();
  currentRoomId$ = this._currentRoomId.asObservable();
  rooms$ = this._rooms.asObservable();
  users$ = this._users.asObservable();
  currentRoomMessages$ = this._currentRoomMessages.asObservable();

  switchRoom(roomId: string): void {
    this._currentRoomMessages.next([]);
    this._currentRoomId.next(roomId);
    this.loadMessagesForRoom(roomId);
  }

  sendMessage(message: string): void {
    const roomId = this._currentRoomId.value;
    if (!roomId) return;

    const newMessage: Message = {
      roomId,
      userId: '1',
      message,
      timestamp: Date.now(),
    };

    this._currentRoomMessages.next([
      ...this._currentRoomMessages.value,
      newMessage,
    ]);
  }

  private loadMessagesForRoom(roomId: string): void {
    // GET /api/rooms/{roomId}/messages
    this._currentRoomMessages.next([]);
  }
}
