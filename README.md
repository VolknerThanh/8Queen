# Bài toán tám hậu


### Mô tả bài toán
---

* Input : vị trí của con hậu đầu tiên (vị trí bất kỳ)
* Output: In ra vị trí của 7 con hậu còn lại (không ăn lẫn nhau)

### Một số thông tin về quân hậu
---
* quân hậu là quân cờ có thể đi được đường ngang, đường dọc và 2 đường chéo

### Giải thuật về bài toán
---


1. Tạo bàn cờ bằng ma trận kích thước 8x8
> ```cshape
>   map = new int[8,8];
> ```

2. Đưa tọa độ của con hậu đầu tiên vào input
>
3. Khai báo 1 biến `int k` để xác định số lượng quân hậu
4. Thiết lập ô con hậu có thể đi được (đường đi của quân hậu)
5. Tìm các con hậu kế cận (không được nằm trên đường đi của các con hậu trước đó) và xác định vị trí của nó (con hậu có đường đi mà số ô trống còn lại trên bàn cờ nhiều nhất)
6. Gán tọa độ của con hậu tại (

