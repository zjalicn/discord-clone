import { NgModule } from '@angular/core';
import { LucideAngularModule, Send } from 'lucide-angular';

@NgModule({
  imports: [
    LucideAngularModule.pick({
      Send,
    }),
  ],
  exports: [LucideAngularModule],
})
export class IconsModule {}
