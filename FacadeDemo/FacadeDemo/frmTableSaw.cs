using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FacadeDemo
{
  public partial class frmTableSaw : Form
  {
    TableSaw ts;
    DustCollector dc;
    AirFilter af;
    UniversalShopRemote usr;

    public frmTableSaw()
    {
      InitializeComponent();
      ts = new TableSaw();
      dc = new DustCollector();
      af = new AirFilter();
      ts.SawStateChanged += new SawStateChangedEventhandler(ts_SawStateChanged);
      dc.DustCollectorStateChanged += new DustCollectorStateChangedEventHandler(dc_DustCollectorStateChanged);
      af.AirFilterStateChanged += new AirFilterStateChangedEventHandler(af_AirFilterStateChanged);
      UpdateControls();
    }

    void af_AirFilterStateChanged(object sender, EventArgs e)
    {
      UpdateControls();
    }

    void dc_DustCollectorStateChanged(object sender, EventArgs e)
    {
      UpdateControls();
    }

    void ts_SawStateChanged(object sender, EventArgs e)
    {
      UpdateControls();
    }

    public void UpdateControls()
    {
      m_tbBladeHeight.Text = ts.m_BladeHeight.ToString();
      m_tbDustPort.Text = ts.m_DustPortState.ToString();
      m_tbFence.Text = ts.m_FenceState.ToString();
      if (ts.m_FenceState == TableSaw.Fence.present)
        m_tbFence.Text += " (at " + ts.m_FencePosition.ToString() + ")";
      m_tbGuard.Text = ts.m_BladeGuardState.ToString();
      m_tbMiter.Text = ts.m_MiterState.ToString();
      m_tbPower.Text = ts.m_PowerState.ToString();
      m_tbAirFilterState.Text = af.m_AirFilterState.ToString();
      m_tbDustCollectorState.Text = dc.m_State.ToString();
    }

    private void m_btnThroughRipCut_Click(object sender, EventArgs e)
    {
      float BladeHeight;
      float FencePosition;

      if ((float.TryParse(m_tbBladeHeightPreference.Text, out BladeHeight)) &&
          (float.TryParse(m_tbFencePositionPreference.Text, out FencePosition)))
        if (ts.ThroughRipCut(FencePosition, BladeHeight))
          UpdateControls();
    }

    private void m_btnThroughCrossCut_Click(object sender, EventArgs e)
    {
      float BladeHeight;
      float FreeEnd;

      if ((float.TryParse(m_tbBladeHeightPreference.Text, out BladeHeight)) &&
          (float.TryParse(m_tbFencePositionPreference.Text, out FreeEnd)))
        if (ts.ThroughCrossCut(FreeEnd, BladeHeight))
          UpdateControls();

    }

    private void m_btnRabbetRipCut_Click(object sender, EventArgs e)
    {
      float BladeHeight;
      float FencePosition;

      if ((float.TryParse(m_tbBladeHeightPreference.Text, out BladeHeight)) &&
          (float.TryParse(m_tbFencePositionPreference.Text, out FencePosition)))
        if (ts.RabbetRipCut(FencePosition, BladeHeight))
          UpdateControls();

    }

    private void m_btnRabbetCrossCut_Click(object sender, EventArgs e)
    {
      float BladeHeight;
      float FreeEnd;

      if ((float.TryParse(m_tbBladeHeightPreference.Text, out BladeHeight)) &&
          (float.TryParse(m_tbFencePositionPreference.Text, out FreeEnd)))
        if (ts.RabbetCrossCut(FreeEnd, BladeHeight))
          UpdateControls();

    }

    private void m_btnStart_Click(object sender, EventArgs e)
    {
      ts.Start();
    }

    private void m_btnStop_Click(object sender, EventArgs e)
    {
      ts.Stop();
    }

    private void m_btnDustCollectorOff_Click(object sender, EventArgs e)
    {
      dc.m_State = DustCollector.DustCollectorState.off;
    }

    private void m_btnDustCollectorMedium_Click(object sender, EventArgs e)
    {
      dc.m_State = DustCollector.DustCollectorState.medium;
    }

    private void m_btnDustCollectorHigh_Click(object sender, EventArgs e)
    {
      dc.m_State = DustCollector.DustCollectorState.high;
    }

    private void m_AirFilterOff_Click(object sender, EventArgs e)
    {
      af.m_AirFilterState = AirFilter.AirFilterState.off;
    }

    private void m_btnAiFilterMedium_Click(object sender, EventArgs e)
    {
      af.m_AirFilterState = AirFilter.AirFilterState.medium;
    }

    private void m_btnAirFilterHigh_Click(object sender, EventArgs e)
    {
      af.m_AirFilterState = AirFilter.AirFilterState.high;
    }

    private void m_btnShowUniversalRemote_Click(object sender, EventArgs e)
    {
      if (m_btnShowUniversalRemote.Text == "U")
        ShowUniversalRemote();
      else
        HideUniversalRemote();
    }

    private void ShowUniversalRemote()
    {
        this.Size = new Size(1241, this.Size.Height);
        usr = new UniversalShopRemote(ts,dc,af);
        m_gbUniversalRemote.Visible = true;
        m_btnShowUniversalRemote.Text = "H";
    }

    private void HideUniversalRemote()
    {
        this.Size = new Size(930, this.Size.Height);
        m_gbUniversalRemote.Visible = false;
        m_btnShowUniversalRemote.Text = "U";
    }

    private void m_btnURThroughCrossCut_Click(object sender, EventArgs e)
    {
      usr.ThroughCrossCut(float.Parse(m_tbFencePositionPreference.Text), 
                          float.Parse(m_tbBladeHeight.Text));
    }

    private void m_btnURThroughRipCut_Click(object sender, EventArgs e)
    {
      usr.ThroughRipCut(float.Parse(m_tbFencePositionPreference.Text), 
                          float.Parse(m_tbBladeHeight.Text));

    }

    private void m_btnURRabbetCrossCut_Click(object sender, EventArgs e)
    {
      usr.RabbetCrossCut(float.Parse(m_tbFencePositionPreference.Text), 
                          float.Parse(m_tbBladeHeight.Text));

    }

    private void m_btnURRabbetRipCut_Click(object sender, EventArgs e)
    {
      usr.RabbetRipCut(float.Parse(m_tbFencePositionPreference.Text), 
                          float.Parse(m_tbBladeHeight.Text));

    }
  }
}
