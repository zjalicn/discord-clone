import { Room } from './room';
import { User } from './user';

export interface ChatRoom {
  chatRoomId: string;
  name: string;
  rooms: Room[];
  users: User[];
}
