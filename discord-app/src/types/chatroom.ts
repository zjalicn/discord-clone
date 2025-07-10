import { Room } from './room';
import { User } from './user';

export interface ChatRoom {
  chatRoomId: string;
  name: string;
  room: Room;
  users: User;
}
