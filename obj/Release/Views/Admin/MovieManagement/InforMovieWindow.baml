   M S B A M L   `   `   `  ����   cinema-managementD    >cinema_management.Views.Admin.MovieManagement.InforMovieWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     _ [MaterialDesignThemes.Wpf, Version=5.0.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  -     �Name$
  main��   MovieManagementVM � DataContext# [    MaterialDesignBody#���  $��Regular"�&   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�   TextRenderingMode$
 Auto=� � WindowStartupLocation$ CenterScreen=� � WindowStyle$
 None=� � AllowsTransparency . $��arial)�
������ $	��650��$
��1000�� � Triggers :�  :� RoutedEvent$ Window.Loaded��.[��� .���� .��W� 	 �� 
TargetName$
	 main��
 �� TargetProperty$
 Opacity� W� From$ 0X�	 W� To$ 1X� g� Duration$ 0:0:0.3D�.��� .+��� ���	#FFF0F3F7 �� CornerRadius$ 10��
�������$��1q�._��  � RowDefinitions �� $��50 ��� $	��40* ��� $	��60* �.+�� $��0��.+��� $��0,0,0,1q�
���   �._�� .+��� $��Chi tiết phim��$��25(�$��	20,10,0,0q�$
��Bold"���  �� Orientation$ 
Horizontal=�$	��Top=�$��Right=�$��0��.+��� -    c� OverflowMode$ AsNeeded=�
������ 
���   �
������ +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 0,10,0,0������ *	CloseCM+����  �� ElementName$
 main��.��'  !MaterialDesignThemes.Wpf.PackIcon     Kind$ WindowClose=�$��0q�� $��1��$��0,10,0,0q� �� �� .+�� $��0��$��0,24,0,0q� � ColumnDefinitions �� $	��65* ��� $	��45* �.+��� $��0��$��	25,0,25,0q�.+��� .+��� $��	Tên phim��$��20(�$��36���� $��0q�  MaterialDesignFilledTextBox#��[ $	��Top=� �� AcceptsReturn .  �� TextWrapping$
 Wrap=�$��22(�|�.  ���	#FFF0F3F7
���   �$��50������ *	movieName+�� $��1��$��0,0,25,0q�.+��� $��Thể loại��$��20(��� -    ��Name$ Genre��|�.  $��25(�$��0,0,0,1q�$��50��$��Bottom=�� $��1��$��0,10,0,0q� �� $
��292* ��� $
��110* ��� $	��97* �.+��� $��0��$��
25,10,10,0q�.+��� $��0��.+��� $��
Tác giả��$��20(�$��0,0,35,0q�$��35����  . $
 Wrap=�$��25(����	#FFF0F3F7$��0q�|�.  $��Center=�$��40��$��0,0,10,0q����� *movieDirector+�� $��1��$��	0,10,10,0q�.+��� $��
Quốc gia��$��20(�$��35���� .+��� $��22(�$��40��|�.  $��Bottom=����� *movieCountry+�� $��2��$��	0,10,25,0q�.+��� $��Thời lượng��$��20(�$��40���� .+��� $��35��$��22(�|�.  ���� *movieDuration+.��� $��2��.+��  �� $	��75* ��� $	��25* �.+�� $��0�� �� �� .+��� $
��Left=�$ 
Horizontal=�$��25,0,0,0q�$��2��$	��773��.+��� .+��� $��Mô tả��$��20(�
���   �$��0,10,0,0q���  ! MaterialDesignOutlinedTextBox#��[ $	��Top=� . $
 Wrap=�" �� VerticalScrollBarVisibility$
 Auto=�$ �� HorizontalScrollBarVisibility$ Disabled=�|�.  $��18(�$	��300��$	��400��
���   ����� *
movieDes+�� $��
30,10,0,00q�$	��346��.+��� -    ��Name$ 
imageframe��$	��300��$	��210��$
��Left=�$��0,30,0,0q����� *ImageSource+� $��1�� �� �� .+�� $��0��.+��� $��0,0,25,0q�$��Right=�.+��� $��Năm phát hành��$��20(�$��31��$��0,10,0,0q�� .+��� -   $
 Year��$��25(�
������ $	��Top=�$��48��$��	0,-15,0,0q�$��0q�|�.  $��Bottom=����� *	movieYear+