using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SliderDirection
{
    Horizontal,
    Vertical
}

public class GUISlider : GUIBase
{
    public float minValue = 0; // 最小值
    public float maxValue = 100; // 最大值
    public float value = 50; // 当前值
    public SliderDirection direction = SliderDirection.Horizontal; // 滑动方向
    public GUIStyle thumbStyle; // 滑块样式

    public event UnityEngine.Events.UnityAction<float> valueChangedEvent; // 值改变事件

    float lastValue = 50; // 上一次的值
    protected override void DrawControlNoStyle()
    {
        if (this.direction == SliderDirection.Horizontal)
            this.value = GUI.HorizontalSlider(this.guiPos.pos, this.value, this.minValue, this.maxValue);
        else
            this.value = GUI.VerticalSlider(this.guiPos.pos, this.value, this.minValue, this.maxValue);

        // 检测值变化,触发事件
        if (this.value != lastValue)
        {
            lastValue = this.value;
            valueChangedEvent?.Invoke(this.value);
        }
    }

    protected override void DrawControlUseStyle()
    {
        if (this.direction == SliderDirection.Horizontal)
            this.value = GUI.HorizontalSlider(this.guiPos.pos, this.value, this.minValue, this.maxValue, this.guiStyle, this.thumbStyle);
        else
            this.value = GUI.VerticalSlider(this.guiPos.pos, this.value, this.minValue, this.maxValue, this.guiStyle, this.thumbStyle);
        // 检测值变化,触发事件
        if (this.value != lastValue)
        {
            lastValue = this.value;
            valueChangedEvent?.Invoke(this.value);
        }
    }
}
