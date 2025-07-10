import { Message } from './message';
import { User } from './user';

export interface Room {
  roomId: string;
  name: string;
  users: User[];
  messages: Message[];
}
