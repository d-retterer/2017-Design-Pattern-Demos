using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FacadeDemo
{
  public delegate void SawStateChangedEventhandler(object sender, EventArgs e);

  public class TableSaw
  {
    public enum Power { off, on }
    public enum DustCollection { closed, open }
    public enum BladeGuard { installed, removed }
    public enum Miter { present, absent }
    public enum Fence { present, absent }
    private Power _PowerState;
    private DustCollection _DustPortState;
    private BladeGuard _BladeGuardState;
    private Miter _MiterState;
    private Fence _FenceState;
    private float _FencePosition;
    private float _Bladeheight;

    public Power m_PowerState
    {
      get { return _PowerState; }
      set
      {
        _PowerState = value;
        if (SawStateChanged != null)
          SawStateChanged(this, new EventArgs());
      }
    }

    public DustCollection m_DustPortState
    {
      get { return _DustPortState; }
      set
      {
        _DustPortState = value;
        if (SawStateChanged != null)
          SawStateChanged(this, new EventArgs());
      }
    }

    public BladeGuard m_BladeGuardState
    {
      get { return _BladeGuardState; }
      set
      {
        _BladeGuardState = value;
        if (SawStateChanged != null)
          SawStateChanged(this, new EventArgs());
      }
    }
    public Miter m_MiterState
    {
      get { return _MiterState; }
      set
      {
        _MiterState = value;
        if (SawStateChanged != null)
          SawStateChanged(this, new EventArgs());
      }
    }

    public Fence m_FenceState
    {
      get { return _FenceState; }
      set
      {
        _FenceState = value;
        if (SawStateChanged != null)
          SawStateChanged(this, new EventArgs());
      }
    }

    public float m_FencePosition
    {
      get { return _FencePosition; }
      set
      {
        _FencePosition = value;
        if (SawStateChanged != null)
          SawStateChanged(this, new EventArgs());
      }
    }

    public float m_BladeHeight
    {
      get { return _Bladeheight; }
      set
      {
        _Bladeheight = value;
        if (SawStateChanged != null)
          SawStateChanged(this, new EventArgs());
      }
    }

    public event SawStateChangedEventhandler SawStateChanged;


    public bool ThroughRipCut(float FencePosition, float BladeHeight)
    {
      m_PowerState = Power.off;
      m_DustPortState = DustCollection.closed;
      m_BladeGuardState = BladeGuard.installed;
      m_BladeHeight = BladeHeight;
      m_MiterState = Miter.absent;
      m_FenceState = Fence.present;
      m_FencePosition = FencePosition;


      return true;
    }

    public bool ThroughCrossCut(float FreeEnd, float BladeHeight)
    {
      m_PowerState = Power.off;
      m_DustPortState = DustCollection.closed;
      m_BladeGuardState = BladeGuard.installed;
      m_BladeHeight = BladeHeight;
      m_MiterState = Miter.present;
      if (FreeEnd > 25)
        m_FenceState = Fence.absent;
      else
      {
        m_FenceState = Fence.present;
        m_FencePosition = FreeEnd + 1.0f;
      }

      return true;
    }

    public bool RabbetRipCut(float FencePosition, float BladeHeight)
    {
      m_PowerState = Power.off;
      m_DustPortState = DustCollection.closed;
      m_BladeGuardState = BladeGuard.removed;
      m_BladeHeight = BladeHeight;
      m_MiterState = Miter.absent;
      m_FenceState = Fence.present;

      return true;
    }

    public bool RabbetCrossCut(float FreeEnd, float BladeHeight)
    {
      m_PowerState = Power.off;
      m_DustPortState = DustCollection.closed;
      m_BladeGuardState = BladeGuard.removed;
      m_BladeHeight = BladeHeight;
      m_MiterState = Miter.present;
      if (FreeEnd > 25)
        m_FenceState = Fence.absent;
      else
      {
        m_FenceState = Fence.present;
        m_FencePosition = FreeEnd + 1.0f;
      }

      return true;
    }

    public bool Start()
    {
      m_DustPortState = DustCollection.open;
      Application.DoEvents();
      System.Threading.Thread.Sleep(3000);
      m_PowerState = Power.on;

      return true;
    }

    public bool Stop()
    {
      m_PowerState = Power.off;
      m_DustPortState = DustCollection.closed;
      return true;
    }
  }
}
