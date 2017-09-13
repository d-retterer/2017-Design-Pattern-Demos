using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FacadeDemo
{
  public delegate void DustCollectorStateChangedEventHandler(object sender, EventArgs e);
  public class DustCollector
  {
    public enum DustCollectorState {off, medium, high}
    public event DustCollectorStateChangedEventHandler DustCollectorStateChanged;
    private DustCollectorState _State;

    public DustCollectorState m_State
    {
      get
      {
        return _State;
      }

      set
      {
        _State = value;
        if (DustCollectorStateChanged != null)
          DustCollectorStateChanged(this, new EventArgs());
      }

    }

  }
}
