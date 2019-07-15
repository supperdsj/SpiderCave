* 利用变量控制 Animator （anim.SetBool("Walk",true);）
* 配合 FixedUpdate 实现按键控制
* 利用刚体位移实现移动
* transform.localScale 改变人物朝向
* 无摩擦力的作用下，应考虑合力问题（如空中操作）
* 为对象的 Collider 的 Material 设置 New Physics Material 2D 来实现弹力 
* IEnumerator 递归实现循环攻击
* collision = Physics2D.Linecast(startPos.position, endPos.position, 1 << LayerMask.NameToLayer("Ground"));//获取特定Layer起止点的平面
* 雪碧图切片时除自动外还可选择平均距离切
