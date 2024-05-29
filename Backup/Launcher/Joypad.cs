// Decompiled with JetBrains decompiler
// Type: Launcher.Joypad
// Assembly: Launcher, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6AA362FF-B506-4D02-B128-5EAE460AD817
// Assembly location: C:\Program Files (x86)\Ubisoft\Rabbids Go Home - DVD\Launcher.exe

using Microsoft.DirectX.DirectInput;
using System.Threading;

#nullable disable
namespace Launcher
{
  public class Joypad
  {
    private AutoResetEvent JOYSTICK_EVENT = new AutoResetEvent(true);
    private WaitHandle[] WAIT_FOR = new WaitHandle[1];
    private Device joyDevice;
    private byte[] state;

    public event JoypadHandler JoypadPress;

    public Joypad()
    {
      this.WAIT_FOR[0] = (WaitHandle) this.JOYSTICK_EVENT;
      this.joyDevice = Joypad.GetJoypadDevice();
      new Thread(new ThreadStart(this.JoyPress)).Start();
      this.joyDevice.SetEventNotification((WaitHandle) this.JOYSTICK_EVENT);
      this.joyDevice.Acquire();
    }

    public static Device GetJoypadDevice()
    {
      DeviceList devices = Manager.GetDevices(DeviceType.Joystick, EnumDevicesFlags.AttachedOnly);
      if (devices.Count <= 0)
        return (Device) null;
      devices.MoveNext();
      return new Device(((DeviceInstance) devices.Current).InstanceGuid);
    }

    public void Update()
    {
      this.joyDevice.Poll();
      this.state = this.joyDevice.CurrentJoystickState.GetButtons();
    }

    public int GetJoypadButtonDown()
    {
      for (int joypadButtonDown = 0; joypadButtonDown < this.state.Length; ++joypadButtonDown)
      {
        if (this.state[joypadButtonDown] != (byte) 0)
          return joypadButtonDown;
      }
      return -1;
    }

    private void JoyPress()
    {
      while (true)
      {
        do
        {
          WaitHandle.WaitAll(this.WAIT_FOR);
          this.Update();
        }
        while (this.GetJoypadButtonDown() == -1);
        this.JoypadPress();
      }
    }

    private void OnJoypadPress()
    {
    }
  }
}
