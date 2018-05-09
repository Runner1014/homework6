# homework6

订阅-发布模式：用委托和事件实现，订阅者实现函数，并绑定到发布者的事件上，这样当事件触发时，一系列绑定到该事件的方法都会执行。

* 发布者关键代码：
delegate void a();
event a aEvent;

* 订阅
void b();
aEvent += b;

当aEvent触发时，b方法会执行。

博客链接：https://blog.csdn.net/Runner1st/article/details/80260049  
视频链接：（审核中）
