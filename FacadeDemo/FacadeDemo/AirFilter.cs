using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FacadeDemo
{
  public delegate void AirFilterStateChangedEventHandler(object sender, EventArgs e);

  public class AirFilter
  {
    public event AirFilterStateChangedEventHandler AirFilterStateChanged;
    public enum AirFilterState { off, medium, high }

    private AirFilterState _AirFilterState;

    public AirFilterState m_AirFilterState
    {
      get
      {
        return _AirFilterState;
      }

      set
      {
        _AirFilterState = value;
        if (AirFilterStateChanged != null)
          AirFilterStateChanged(this, new EventArgs());
      }

    }

  }

}
