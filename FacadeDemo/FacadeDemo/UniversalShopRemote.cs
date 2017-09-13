using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FacadeDemo
{
  public class UniversalShopRemote
  {
    private TableSaw m_ts;
    private DustCollector m_dc;
    private AirFilter m_af;

    public UniversalShopRemote(TableSaw ts, DustCollector dc, AirFilter af)
    {
      m_ts = ts;
      m_dc = dc;
      m_af = af;
    }

    public bool ThroughCrossCut(float FreeEnd, float BladeHeight)
    {
      bool RetVal;

      RetVal = m_ts.ThroughCrossCut(FreeEnd, BladeHeight);
      m_dc.m_State = DustCollector.DustCollectorState.medium;
      m_af.m_AirFilterState = AirFilter.AirFilterState.off;

      return RetVal;
    }

    public bool ThroughRipCut(float FreeEnd, float BladeHeight)
    {
      bool RetVal;

      RetVal = m_ts.ThroughRipCut(FreeEnd, BladeHeight);
      m_dc.m_State = DustCollector.DustCollectorState.high;
      m_af.m_AirFilterState = AirFilter.AirFilterState.off;

      return RetVal;
    }

    public bool RabbetRipCut(float FreeEnd, float BladeHeight)
    {
      bool RetVal;

      RetVal = m_ts.RabbetCrossCut(FreeEnd, BladeHeight);
      m_dc.m_State = DustCollector.DustCollectorState.high;
      m_af.m_AirFilterState = AirFilter.AirFilterState.high;

      return RetVal;
    }

    public bool RabbetCrossCut(float FreeEnd, float BladeHeight)
    {
      bool RetVal;

      RetVal = m_ts.RabbetCrossCut(FreeEnd, BladeHeight);
      m_dc.m_State = DustCollector.DustCollectorState.high;
      m_af.m_AirFilterState = AirFilter.AirFilterState.medium;

      return RetVal;
    }
  }
}
