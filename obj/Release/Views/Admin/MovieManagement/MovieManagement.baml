   M S B A M L   `   `   `  ����   cinema-managementC    =cinema_management.Views.Admin.MovieManagement.MovieManagement   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     _ [MaterialDesignThemes.Wpf, Version=5.0.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  -     N�Name$  mainPage��   MaterialDesignBody#���   $��Regular"�$��13(�&   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�   TextRenderingMode$
 Auto=�  MovieManagementVM � DataContext# [  N� 
FontFamily$ arial)�*  $Microsoft.Xaml.Behaviors.Interaction   Triggers +  %Microsoft.Xaml.Behaviors.EventTrigger     	EventName$ Loaded��*  $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 2  ,Microsoft.Xaml.Behaviors.InvokeCommandAction     Command �� *
MaskNameCM+	   CommandParameter	 �� 
 �� ElementName$
 
ShadowMask��   �� *FirstLoadCM+ � Triggers :�  :� RoutedEvent$ Page.Loaded��.[��� .���� .��W�  �� 
TargetName$ mainPage�� �� TargetProperty$ Opacity� W� From$ 0X�	 W� To$ 1X� g� Duration$ 0:0:0.3D�.��� ���#f0f2f5 � RowDefinitions �� $	��10* ��� $	��90* �.+��� $��0�� �� Orientation$ 
Horizontal=�$��30,0,0,0q�.+��� -    ��Name$ 	FilterBox��)  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Tìm kiếm��$��25(����	#DD000000$��Arial)� J� 	AllowDrop . $��0,0,0,1q�$	��500��$��30��$��0q�$��Bottom=�.���� $ 
Horizontal=�$��30,0,0,0q�$��Bottom=�.+��� $	��Top=�$��Center=�$	��120��$��40��$��25(�$��arial)�$��0q�+  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 8������ *LoadAddMovieCM+���� $ 
Horizontal=�.+�'  !MaterialDesignThemes.Wpf.PackIcon     Kind$ PlusCircleOutline=�$��25��$��25��$��Center=�$��0,0,0,0q��� $��Thêm��$��5,0,0,0q�� $��1��.+�#	  MaterialDesignThemes.Wpf.Card	  
�������$��30,20,30,20q� 	  UniformCornerRadius$ 5Q�.���� .+��� -    ��Name$ MovieListView��|�. $	��578�� � ToolTip$&  Nháy đúp để xem chi tiết������ *	MovieList+ �� SelectedItem �� *SelectedItem+   $ MouseDoubleClick��.    �� *LoadInforMovieCM+ �� View �� .P��� $��	Tên phim�� �� Width$	 450�� �� CellTemplate �� .R��� $��18(����� *DisplayName+�� $��Loại phim��$	 150�� �� .R��� $��30,0,0,0q�$��18(����� *	MovieType+�� $��
Quốc gia��$	 180�� �� .R��� $��20,0,0,0q�$��18(����� *	Country+�� $��Thể loại�� �� .R��� $��20,0,0,0q�$��18(����� *Genres[0].DisplayName+�� $��Thời lượng(phút)��$	 200�� �� .R��� $��40,0,0,0q�$��18(����� *RunningTime+��  �� .R��� $ 
Horizontal=�.+��� 
���   �$	��0.5q�  �� CornerRadius$  5��! � Cursor$
! Hand������ " �� 
TargetType"" ��# �� Triggers# P� $ P� Property$ �@J�IsMouseOver% P� Value% . . ��� & �� Property& � ��' �� Value' �#00e5ff._��� .+��� $ ��/Resources/Icon/pencil.png��$��30��$��30��   $ MouseLeftButtonUp��.    �� $
 MovieListView��( �� Path$!( DataContext.LoadEditMovieCM��� $	��0.5q�
���   �$  5��$��10,0,0,0q�$
! Hand������ "" ��# P� $ �@J�IsMouseOver% . . ��� & � ��' �#ff6255._��� .+�  $ GarbageCanEmpty=�$��30��$��30��   $ MouseLeftButtonUp��.    �� $
 MovieListView��$#( DataContext.LoadDeleteMovieCM�� .+��� $ 
Horizontal=�$��Right=�$��0,0,20,0q�.+��� $��Kết quả: ��$��15(��� -   ) ��Name$) result��$��15(����� *MovieList.Count+�  % !MaterialDesignCircularProgressBar#��[ $	��100��$	��100��$��
0,-700,0,0q�* � IsIndeterminate* �� *
IsLoadding+� -   + �Name$+ 
ShadowMask��$��2��
�������, J� Opacity$	, 0.3Q�$y�	Collapsed=�