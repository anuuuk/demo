   M S B A M L   `   `   `  ����?  ;avta, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:avtaavta  5   	       avta.ChangePasswordWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   $localclr-namespace:avta     5   	     � Title$  ChangePasswordWindow��5   	   $	��450��6&   $	��800��63   .��5	      � $��20q�6    � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $
��Wrap=�6   $��Смена пароля��6)   $��Center=�6=   $��Center=�6Z   �� 5      $��1��6   $	��300��6&   .+�5      �� $��Center=�6   $
��Wrap=�6;   $!��Текущий пароль��6O   G� 5   
   -   5         G�Name$ txtCurrentPassword��5      $	��150��66   �� 5      $��Center=�6   $
��Wrap=�67   $��Новый пароль��6K   G� 5   
   -   5        $ txtNewPassword��5      $	��150��62   �� 5      $��Center=�6   $
��Wrap=�66   $2��,Подтверите новый пароль��6J   G� 5   
   -   5        $ txtConfirmNewPassword��5      $	��150��69   �� 5      -   5        $#��Изменить пароль��5      $	��150��6/   $��Center=�6;   6X   5      5      5      