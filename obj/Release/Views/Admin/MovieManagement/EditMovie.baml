   M S B A M L   `   `   `  ����   cinema-management=    7cinema_management.Views.Admin.MovieManagement.EditMovie   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  _ [MaterialDesignThemes.Wpf, Version=5.0.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  -     �Name$  EditMovieWindow��   MaterialDesignBody#���   $��Regular"�&   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�   TextRenderingMode$
 Auto=� � WindowStartupLocation$ CenterScreen=� � WindowStyle$
 None=� � AllowsTransparency . 
������   MaterialDesignFont#���    MovieManagementVM � DataContext# [ $	��650��$
��1000�� � Triggers :�  :� RoutedEvent$ Window.Loaded��.[��� .���� .��W� 	 �� 
TargetName$	 EditMovieWindow��
 �� TargetProperty$
 Opacity� W� From$ 0X�	 W� To$ 1X� g� Duration$ 0:0:0.3D�.��� .+��� ���	#FFF0F3F7 �� CornerRadius$ 10��
�������$��1q�._��  � RowDefinitions �� $��50 ��� $	��40* ��� $	��60* �.+�� $��0��.+��� $��0,0,0,1q�
���   �+  %MaterialDesignThemes.Wpf.ShadowAssist   ShadowAnimationDuration$
 2000h�._�� .+��� $��Chỉnh sửa phim��$��25(�$��	20,10,0,0q�$
��Bold"���  �� Orientation$ 
Horizontal=�$	��Top=�$��Right=�$��0��.+��� -    c� OverflowMode$ AsNeeded=�
������ 
���   �
������ +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 0,10,0,0������ *	CloseCM+����  �� ElementName$ EditMovieWindow��.��'  !MaterialDesignThemes.Wpf.PackIcon     Kind$ WindowClose=�$��0q�� $��1��$��0,10,0,0q� �� �� .+�� $��0��$��0,24,0,0q� � ColumnDefinitions �� $	��65* ��� $	��45* �.+��� $��0��$��	25,0,25,0q�.+��� .+��� $��	Tên phim��$��20(�$��36���� -    ��Name$ _Name��$��0q�  MaterialDesignFilledTextBox#��[ $	��Top=� �� AcceptsReturn .  �� TextWrapping$
 Wrap=�$��22(����	#FFF0F3F7$��0,0,0,1q�
���   �$��50������ *	movieName+ �� Mode$ TwoWay=��� $��1��$��0,0,25,0q�.+��� $��Thể loại��$��20(��� -    ��Name$ _Genre�� �� DisplayMemberPath$ DisplayName�� �� 
IsEditable . $��25(�$��0,20,0,0q�$��0,0,0,1q� �� MaxDropDownHeight$	 280��$��53������ *	GenreList+ �� SelectedItem �� *
movieGenre+$ TwoWay=�� $��1��$��0,10,0,0q� �� $
��292* ��� $
��110* ��� $	��97* �.+��� $��0��$��
25,10,10,0q�.+��� $��0��.+��� $��
Tác giả��$��20(�$��0,0,35,0q�$��35���� -   $ _Author�� . $
 Wrap=�$��25(����	#FFF0F3F7$��0q�$��Center=�$��40��$��0,0,10,0q����� *movieDirector+$ TwoWay=��� $��1��$��	0,10,10,0q�.+��� $��
Quốc gia��$��20(�$��35���� .+��� -   $ _Country�� . $��25(�$��40��$��Bottom=�$	 240������ *ListCountrySource+ �� *movieCountry+$ TwoWay=��� $��2��$��	0,10,25,0q�.+��� $��Thời lượng��$��20(�$��40���� .+��� -   $ 	_Duration��)  #MaterialDesignThemes.Wpf.HintAssist    Hint$  Phút��$��25(�$��Bottom=�$��35������ *movieDuration+$ TwoWay=�� $��2��.+��  �� $	��75* ��� $	��25* �.+�� $��0�� �� �� .+��� $
��Left=�$ 
Horizontal=�$��25,0,0,0q�$��2��$	��773��.+��� .+��� $��Mô tả��$��20(�
���   �$��0,10,0,0q��� -   $ _Descripstion�� ! MaterialDesignOutlinedTextBox#��[ $	��Top=� . $
 Wrap=�"! �� VerticalScrollBarVisibility$
! Auto=�$" �� HorizontalScrollBarVisibility$" Disabled=�$  Giới thiệu phim��$��18(�$	��300��$	��400��
���   ����� *
movieDes+$ TwoWay=��� $��
30,10,0,00q�$	��346��$ 
Horizontal=�.+��� 
���   �$��1q�$	��210��$	��300��$��0,15,0,0q�._��� -	   # ��Name$# imgframe������ *ImageSource+$ TwoWay=��� $��0q�$��50��$��Bottom=�$��	10,0,0,17q�$ 5������ *UploadImageCM+��  $ FolderUpload=�$��23��$��25���� $��	210 x 300��$��Bottom=�$��
-270,0,0,0q�$��20��� $��1�� �� �� .+�� $��0��.+��� $��0,0,25,0q�$��Right=�.+��� $��Năm phát hành��$��20(�$��31��$��0,10,0,0q�� .+��� -
   $
 Year��
������ $��0q�$��22(�$��5,0,0,0q����� *	movieYear+$ TwoWay=�� $��1��.+��� $��Bottom=�$��Right=�$ 
Horizontal=�$��0,0,0,10q�.+��� $
��Lưu��$��20(�$��40��$	��100��$��
10,0,10,10q�$ 8������ *UpdateMovieCM+���� $ EditMovieWindow��� $��3��
�������$ J� Opacity$	$ 0.3Q����� % �� 
TargetType"% �.��� & �� Property& � y�' �� Value$' 	Collapsed=�( �� Triggers( �� ) �� Binding) �� *
IsSaving+* �� Value* True.a��� & � y�$' Visible=�#  MaterialDesignThemes.Wpf.Card  $	��100��$	��100��$��3��+   UniformCornerRadius$+ 5Q�.���� .+�� -   , �Name$	, prg�� % !MaterialDesignCircularProgressBar#��[ - � IsIndeterminate- . $��0,30,0,0q��� $��Center=�$��15(�$��Đang xử lý...��$��0,10,0,0q����� "%  .��� & � y�$' 	Collapsed=�( �� ) �� *
IsSaving+* True.a��� & � y�$' Visible=�